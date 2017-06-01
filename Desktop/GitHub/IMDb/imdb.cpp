/* Copyright 2017 */

#include <string.h>
#include <iterator>
#include <string>
#include <vector>
#include <iostream>
#include <unordered_map>
#include <iomanip>
#include <algorithm>
#include "include/imdb.h"
#include "include/treap.h"
#include "include/MyClasses.h"

// Constructor
IMDb::IMDb()
{
    // initializarile necesare
    longest_career = -1;
    longest_career_act = "";
    most_influential = -1;
    most_influential_dir = "";
    verify = 0;
}

// Destructor
IMDb::~IMDb()
{
}

void IMDb::add_movie(std::string movie_name,
    std::string movie_id,
    int timestamp,  // unix timestamp when movie was launched
    std::vector<std::string> categories,
    std::string director_name,
    std::vector<std::string> actor_ids)
{
	// adaugarea datelor unui film
    class Movie movie;
    movie.name = movie_name;
    movie.id = movie_id;
    movie.timestamp = timestamp;
    movie.categories = categories;
    movie.director = director_name;
    movie.actors = actor_ids;
    Movies.insert({ movie_id, movie });

    // variabila ce verifica daca s-a adaugat
    // un film inaintea apelarii unei functii
    verify = 1;

    // salvare date necesare pt functia most_popular_movie
    struct Popular pop;
    pop.id = movie_id;
    pop.nr_rating = 0;
    Popular.push_back(pop);

    // adaugarea datelor despre actori
    class Actor actor;

    for (auto&x : actor_ids)
    {
        if (!Actors[x].id.empty())
        {
            Actors[x].movie.push_back(movie_id);
            Actors[x].year.push_back(timestamp);
            // actualizarea datelor pt functia longest_career_actor
            if (Actors[x].get_career() > longest_career)
            {
            	longest_career = Actors[x].get_career();
            	longest_career_act = x;
            }
            else
            {
            	if (Actors[x].get_career() == longest_career)
            	{
            		if (x < longest_career_act)
            		{
            			longest_career = Actors[x].get_career();
            			longest_career_act = x;
            		}
            	}
            }
            for (auto&y : actor_ids)
            {
                int ok = 0;
                if (x != y)
                {
                    for (auto&z : Actors[x].colleagues)
                    {
                        if (y == z)
                        {
                            ok = 1;
                            break;
                        }
                    }
                    if (ok == 0)
                    {
                        Actors[x].colleagues.push_back(y);
                    }
                }
            }
            class Director director_in;
            int ok = 0;
            for (auto& k : Actors[x].director)
            {
                if (k.name == director_name)
                {
                    ok = 1;
                    break;
                }
            }
            if (ok == 0)
            {
                director_in.insert_name(director_name);
                Actors[x].director.push_back(director_in);
            }
        }
        else
        {
            Actors[x].id = x;
            Actors[x].movie.push_back(movie_id);
            Actors[x].year.push_back(timestamp);
            for (auto&y : actor_ids)
            {
                if (x != y)
                {
                    Actors[x].colleagues.push_back(y);
                }
            }
            class Director director_in;
            director_in.insert_name(director_name);
            Actors[x].director.push_back(director_in);
        }
    }
    // adaugarea datelor despre regizori
    class Director director;

    if (Directors[director_name].name.empty())
    {
    	Directors[director_name].name = director_name;

    	for (auto& x : actor_ids)
    	{
    		Directors[director_name].actors.push_back(x);
    	}
    	if (most_influential < Directors[director_name].get_influence())
    	{
    		most_influential = Directors[director_name].get_influence();
    		most_influential_dir = director_name;
    	}
    	else
    	{
    		if (most_influential == Directors[director_name].get_influence())
    		{
    			if (director_name < most_influential_dir)
    			{
    				most_influential_dir = director_name;
    			}
    		}
    	}
    }
    else
    {
    	for (auto& x : actor_ids)
    	{
    		int ok = 0;
    		for (auto& y : Directors[director_name].actors)
    		{
    			if (y == x)
    			{
    				ok = 1;
    				break;
    			}
    		}
    		if (ok == 0)
    		{
    			Directors[director_name].actors.push_back(x);
    		}
    	}
    	// actualizarea datelor pt functia most_influent_director
    	if (most_influential < Directors[director_name].get_influence())
    	{
    		most_influential = Directors[director_name].get_influence();
    		most_influential_dir = director_name;
    	}
    	else
    	{
    		if (most_influential == Directors[director_name].get_influence())
    		{
    			if (director_name < most_influential_dir)
    			{
    				most_influential_dir = director_name;
    			}
    		}
    	}
    }

    // salvare si actualizare date pt functia top_k_pairs
    for (auto& x : actor_ids)
    {
        for (auto& y : actor_ids)
        {
            if (x < y)
            {
                std::string pair = x + " " + y;
                if (Pairs[pair].id.empty())
                {
                    Pairs[pair].id = pair;
                    Pairs[pair].count = 1;
                }
                else
                {
                    Pairs[pair].count++;
                }
            }
        }
    }
}

void IMDb::add_user(std::string user_id, std::string name)
{
    Users[user_id].id = user_id;
    Users[user_id].name = name;
}

void IMDb::add_actor(std::string actor_id, std::string name)
{
    Actors[actor_id].name = name;
    if (Actors[actor_id].id.empty())
    {
        Actors[actor_id].id = actor_id;
    }
}

void IMDb::add_rating(std::string user_id, std::string movie_id, int rating)
{
	verify = 1;
    struct Rating rating1;
    rating1.id_user = user_id;
    rating1.rating = rating;
    Movies[movie_id].rating.push_back(rating1);
    for (auto&x : Popular)
    {
        if (x.id == movie_id)
        {
            x.nr_rating++;
            break;
        }
    }
}

void IMDb::update_rating(std::string user_id, std::string movie_id, int rating)
{
    verify = 1;
    for (auto& x : Movies[movie_id].rating)
    {
        if (x.id_user == user_id)
        {
            x.rating = rating;
            break;
        }
    }
}

void IMDb::remove_rating(std::string user_id, std::string movie_id)
{
	// parcurg vectorul de rating-uri pt un film
	verify = 1;
	int i = 0;
	for (auto& x : Movies[movie_id].rating)
    {
    	// cand il gasesc il sterg
        if (x.id_user == user_id)
        {
            Movies[movie_id].rating.erase(Movies[movie_id].rating.begin() + i);
            break;
        }
		i++;
    }
    // scad nr de rating-uri
    for (auto&x : Popular)
    {
        if (x.id == movie_id)
        {
            x.nr_rating--;
        }
    }
}

std::string IMDb::get_rating(std::string movie_id)
{
    std::string rating = Movies[movie_id].points();
    return rating;
}

std::string IMDb::get_longest_career_actor()
{
    std::string str;
    // daca nu sunt actori care joaca in vreun film
    if (longest_career == -1)
    {
    	return "none";
    }
    // daca sunt actori care au jucat in filme,
    // il returneaza pe cel cu cea mai lunga cariera
    else
    {
    	str = longest_career_act;
    	return str;
    }
}

std::string IMDb::get_most_influential_director()
{
	// returneaza cel mai influent director
    std::string str;
	str = most_influential_dir;
	return str;
}

std::string IMDb::get_best_year_for_category(std::string category)
{
	// folosesc un vector caracteristic pt determinarea anului cautat
    double v[2018] = {0}, max = -1;
    int v2[2018] = {0};
    int year;
    std::string str;
    for (auto& x : Movies )
    {
        for (auto& y : x.second.categories)
        {
            if (y == category)
            {
                if (x.second.points_int() != -1)
                {
                	year = x.second.get_year();
                	v[year] = v[year] + x.second.points_int();
                	v2[year]++;
                }
            }
        }
    }
    // parcurg vectorul caracteristic pentru determinarea anului cautat
    for (int i = 1900; i < 2018; i++)
    {
    	v[i] = v[i] / v2[i];
        if (v[i] > max)
        {
            max = v[i];
            year = i;
        }
    }
    // daca s-a gsit un an
    if (max != -1)
    {
        str = std::to_string(year);
    }
    // daca nu s-a gasit niciun an care sa corespunda cerintei
    else
    {
        str = "none";
    }
    return str;
}

std::string IMDb::get_2nd_degree_colleagues(std::string actor_id)
{
    std::string str;
    // creez un treap pentru sortarea alfabetica
    class Treap <int, class TreapNode<int>> colleagues(compare_int);
    // creez doua hashtable-uri pentru colegii de legatura a doua
    // si unul pentru colegii directi
    std::unordered_map<std::string, std::string> two_nd_colleagues;
    std::unordered_map<std::string, std::string> bad_colleagues;
    bad_colleagues[actor_id] = actor_id;
    int verfy = 0;
    // parcurg colegii directi
    for (auto& x : Actors[actor_id].colleagues)
    {
        bad_colleagues[x] = x;
    }
    for (auto& x : Actors[actor_id].colleagues)
    {
    	// parcurg colegii posibile de legatura a doua
    	// si ii inserez pe cei corecti in treap
        for (auto& y : Actors[x].colleagues)
        {
            if (bad_colleagues[y].empty())
            {
                if (two_nd_colleagues[y].empty())
                {
                    two_nd_colleagues[y] = y;
                    colleagues.insert_info(1, y);
                    verfy = 1;
                }
            }
        }
    }

    // construiesc string-ul cerut
    if (verfy == 0)
    {
        str = "none ";
    }
    else
    {
       str = colleagues.inorder(colleagues.root);
    }
	str = str.substr(0, str.size() - 1);
	return str;
}

std::string IMDb::get_top_k_most_recent_movies(int k)
{
    std::string str;
    // creez un treap pentru calcularea topului
    class Treap <int, class TreapNode<int>> most_recent_movies(compare_int);
    // parcurg fiecare film din hashtable-ul de filme
    for (auto& x : Movies)
    {
    	// introduc in treap datele,
    	// timestamp ca si index si id ca si prioritate
    	most_recent_movies.insert_info(x.second.timestamp, x.first);
    }
    // creez string-ul cerut
    str = most_recent_movies.final_top(most_recent_movies.root, k);
	if (str.empty())
	{
		return "none";
	}
	else
	{
		str = str.substr(0, str.size() - 1);
		return str;
	}
}

std::string IMDb::get_top_k_actor_pairs(int k)
{
    std::string str = "";
    // creez un treap pentru calcularea topului
    class Treap <int, class TreapNode<int>> actor_pairs(compare_int);
    // parcurg hashtable-ul de perechi
    for (auto& x : Pairs)
    {
    	// introduc datele in treap,
    	// nr de aparitii ca si index si id ca si prioritate
        actor_pairs.insert_info(x.second.count, x.second.id);
    }
    // creez string-ul cerut
    str = actor_pairs.final_pairs(actor_pairs.root, k);
	if (str.empty())
	{
		return "none";
	}
	else
	{
		str = str.substr(0, str.size() - 1);
		return str;
	}
}

std::string IMDb::get_top_k_partners_for_actor(int k, std::string actor_id)
{
    std::string str;
    std::unordered_map <std::string, struct Partner> Partners;
    // parcurg vectorul de filme in care a jucat actor_id
    for (auto& x : Actors[actor_id].movie)
    {
        // pentru fiecare film ii adaug partenerii
        // si numarul de filme jucate impreuna
        for (auto& y : Movies[x].actors)
        {
            if (y != actor_id)
            {
                if (Partners[y].id == y)
                {
                    Partners[y].count = Partners[y].count + 1;
                }
                else
                {
                    Partners[y].id = y;
                    Partners[y].count = 1;
                }
            }
        }
    }
    // creez un treap pentru calcularea topului
    class Treap <int, class TreapNode<int>> partners_for_actor(compare_int);
    // parcurg hashtable-ul de parteneri
    for (auto& x : Partners)
    {
    	// introduc datele in treap,
    	// nr de filme jucate impreuna ca si index si
    	// id-ul parterului ca si prioritate
        partners_for_actor.insert_info(x.second.count, x.second.id);
    }
    // creez string-ul cerut
    str = partners_for_actor.final_top(partners_for_actor.root, k);
	if (str.empty())
	{
		return "none";
	}
	else
	{
		str = str.substr(0, str.size() - 1);
		return str;
	}
}

std::string IMDb::get_top_k_most_popular_movies(int k)
{
	std::string str;
	// daca s-a adaugat un film resortez vectorul Popular,
	// in care sunt salvate id-urile si nr de rating-uri primite
    if (verify == 1)
    {
    	std::sort(Popular.begin(), Popular.end());
    	verify = 0;
    }
    // creez string-ul din primele k pozitii ale vectorului
    std::vector <struct Popular> :: iterator it;
    if ( k > (int)Popular.size())
    {
        k = Popular.size();
    }
    for (it = Popular.begin(); it != Popular.begin() + k; it++)
    {
        str = str + it->id + " ";
    }
    if (Popular.size() == 0)
    {
        return "none";
    }
    else
    {
        str = str.substr(0, str.size() - 1);
        return str;
    }
}

std::string IMDb::get_avg_rating_in_range(int start, int end)
{
    std::vector <double> years;
    // parcurg hashtable-ul de filme
    for (auto& x : Movies)
    {
    	// daca se incadreaza in intervalul de timp,
    	// salvez rating-ul pt anul respectiv
        if (start <= x.second.timestamp && x.second.timestamp <= end)
        {
            if (x.second.points_int() != -1)
                years.push_back(x.second.points_int());
        }
    }
    // construiesc rating-ul mediu cerut
    double sum = 0;
    double media = 0;
    std::string str;
    for (auto& x : years)
    {
        sum = sum + x;
    }
    if (years.size() == 0)
    {
        str = "none";
    }
    else
    {
    	// rotunjirea cu doua zecimale si conversia in string
        media = sum/years.size();
        media = round(media * 100.0) / 100.0;
        std::stringstream stream;
        stream << std::fixed << std::setprecision(2) << media;
        str = stream.str();
    }
    return str;
}

