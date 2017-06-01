/* Copyright 2017 */
#ifndef __treap__H__
#define __treap__H__

#include <string.h>
#include <iostream>
#include <string>

// Functia de comparare
template<typename T>
T compare_int(T a, T b)
{
	return (a - b);
}

// Structura unui nod din Treap
template<typename T> class TreapNode
{
 public:
	std::string prio;
	TreapNode<T> *left_son, *right_son;
	// Pointer catre parinte
	TreapNode<T> *parent;
	// Informatia stocata
	T info;

	// Functia de comparare din clasa
	int(*compare)(T, T);

	// Constructor
	TreapNode(int(*compare) (T, T), T info, std::string priority)
	{
		left_son = right_son = parent = NULL;
		this->compare = compare;
		memcpy(&(this->info), &info, sizeof(T));
		prio = priority;
	}

	// Functia de insert
	TreapNode<T>* insert_info(T x, std::string priority)
	{
		int next_son;
		TreapNode<T>* result;

		if (compare(x, info) > 0)
			next_son = 0;
		else
			next_son = 1;
		if(compare(x, info) == 0)
		{
			if(prio > priority)
				next_son = 0;
			else
				next_son = 1;
		}
		if (next_son == 0)
		{  // fiul stang
			if (left_son == NULL)
			{
				left_son = new TreapNode<T>(compare, x, priority);
				left_son->parent = this;
				left_son->push_up();
				result = left_son;
			}
			else
				result = left_son->insert_info(x, priority);
		}
		else
		{  // fiul drept
			if (right_son == NULL)
			{
				right_son = new TreapNode<T>(compare, x, priority);
				right_son->parent = this;
				right_son->push_up();
				result = right_son;
			}
			else
				result = right_son->insert_info(x, priority);
		}
		return result;
	}

	// Functia ce face rotate la dreapta
	void rotate_right()
	{
		TreapNode<T>* gparent = parent->parent;
		TreapNode<T>* rson = right_son;
		parent->left_son = rson;

		if (rson != NULL)
			rson->parent = parent;
		right_son = parent;

		parent->parent = this;

		if (gparent != NULL)
		{
			if (gparent->left_son == parent)
				gparent->left_son = this;
			else
				gparent->right_son = this;
		}
		parent = gparent;
	}

	// Functia ce face rotate la stanga
	void rotate_left()
	{
		TreapNode<T>* gparent = parent->parent;

		TreapNode<T> *lson = left_son;
		parent->right_son = lson;
		if (lson != NULL)
			lson->parent = parent;
		left_son = parent;

		parent->parent = this;

		if (gparent != NULL)
		{
			if (gparent->left_son == parent)
				gparent->left_son = this;
			else
				gparent->right_son = this;
		}
		parent = gparent;
	}

	// Functie folosita pentru aranjarea arborelui in functie de prioritate
	void push_up()
	{
		while (parent != NULL)
		{
			if (prio < parent->prio)
			{
				if (parent->left_son == this)
				{
					rotate_right();
				}
				else
				{
					rotate_left();
				}
			}
			else
				break;
		}
	}

	// Functie folosita pentru aranjarea arborelui in functie de prioritate
	void push_down()
	{
		while (left_son != NULL || right_son != NULL)
		{
			if (left_son == NULL)
				right_son->rotate_left();
			else if (right_son == NULL)
				left_son->rotate_right();
			else
			if (left_son->prio < right_son->prio)
				right_son->rotate_left();
			else
				left_son->rotate_right();
		}
	}

	// Functie ce cauta informatia x in arbore
	TreapNode<T>* find_info(T x)
	{
		if (compare(x, info) == 0)
			return this;

		if (compare(x, info) <= 0)
		{
			if (left_son != NULL)
				return left_son->find_info(x);
			else
				return NULL;
		}
		else
		{
			if (right_son != NULL)
				return right_son->find_info(x);
			else
				return NULL;
		}
	}
};

// Arborele propriu-zis
template<typename T, typename TreeNodeType> class Treap
{
 public:
	TreeNodeType* root;
	int(*compare) (T, T);
	int contor;
	std::string result = "";

	// Constructor
	explicit Treap(int(*compare) (T, T))
	{
		root = NULL;
		this->compare = compare;
		contor = 0;
	}

	// Fuctie necesara dezalocarii
	void DestroyRecursive(TreeNodeType* node)
	{
		if (node)
		{
			DestroyRecursive(node->left_son);
			DestroyRecursive(node->right_son);
			delete node;
		}
	}

	// Destructor
	~Treap()
	{
		DestroyRecursive(root);
	}

	// Functia de insert
	void insert_info(T x, std::string priority)
	{
		if (root == NULL)
			root = new TreeNodeType(compare, x, priority);
		else
		{
			root->insert_info(x, priority);
		}
		while (root->parent != NULL)
			root = root->parent;
	}

	// Functia de cautare
	TreeNodeType* find_info(T x)
	{
		if (root == NULL)
			return NULL;
		else
			return root->find_info(x);
	}

	// Parcurgere inorder
	std::string inorder(TreapNode<int>* root)
	{
		if (root != NULL)
		{
			if (root->left_son != NULL)
			{
				inorder(root->left_son);
			}
			result = result + root->prio + " ";
			if (root->right_son != NULL)
			{
				inorder(root->right_son);
			}
		}
		return result;
	}

	void modify_contor(int k)
	{
		this->contor = k;
	}

	// functie ce returneaza elementele in ordine descrescatoare
	std::string top(TreapNode<int>* root)
	{
		if (root != NULL)
		{
			if (root->left_son != NULL)
			{
				top(root->left_son);
			}

			if (this->contor > 0)
			{
				this->contor--;
				result = result + root->prio + " ";
			}

			if (root->right_son != NULL)
			{
				top(root->right_son);
			}
		}
		return result;
	}

	std::string top_pairs(TreapNode<int>* root)
	{
		if (root != NULL)
		{
			if (root->left_son != NULL)
			{
				top_pairs(root->left_son);
			}

			if (this->contor > 0)
			{
				this->contor--;
				std::string r_info = std::to_string(root->info);
				result = result + "(" + root->prio + " " + r_info + ") ";
			}

			if (root->right_son != NULL)
			{
				top_pairs(root->right_son);
			}
		}
		return result;
	}

	// Functie ce returneaza topul cautat
	std::string final_top(TreapNode<int>* root, int k)
	{
		this->modify_contor(k);
		return this->top(root);
	}

	std::string final_pairs(TreapNode<int>* root, int k)
	{
		this->modify_contor(k);
		return this->top_pairs(root);
	}
};
#endif
