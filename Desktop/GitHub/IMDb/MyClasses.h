/* Copyright 2017 */

#ifndef MYCLASSES_H_
#define MYCLASSES_H_

#include <math.h>
#include <string>
#include <vector>
#include <sstream>
#include <algorithm>
#include <ctime>
#include <iomanip>

// structura Rating, necesara calcularii rating-ului
struct Rating
{
	std::string id_user;
	int rating;
};

// structura necesara functiei get_top_k_most_popular_movies
struct Popular
{
	int nr_rating;
	std::string id;

	// operatorul este folosit pentru sortare dupa rating si id
	bool operator<(const Popular& a) const
    {
    	if(nr_rating != a.nr_rating)
    	{
        	return nr_rating > a.nr_rating;
    	}
        else
        {
       		return id < a.id;
        }
    }
};

// strucura folosita pentru functia get_top_k_partners_for_actor
struct Partner
{
	std::string id;
	int count;
};

// structura folosita pentru functia get_top_k_actor_pairs
struct Pair
{
	std::string id;
	int count;
	// operatorul este folosit pentru sortare dupa count si id
	bool operator<(const Pair& a) const
    {
    	if(count != a.count)
    	{
        	return count > a.count;
    	}
        else
        {
       		return id < a.id;
        }
    }
};

// clasa pentru get_most_influential_director
class Director
{
 public:
	std::string name;
	std::vector <std::string> actors;
	int influence;

	int get_influence()
	{
		return actors.size();
	}
	void insert_name(std::string name_in)
	{
		name = name_in;
	}
};
// clasa folosita in memorarea filmelor
class Movie
{
 public:
	std::string id;
	std::string name;
	int timestamp;
	std::vector <std::string> categories;
	std::string director;
	std::vector <std::string> actors;
	std::vector <struct Rating> rating;

	// returneaza popularitatea(nr de rating-uri primite) unui film
	int get_popularity()
	{
		return rating.size();
	}

	// returneaza rating-ul mediu al unui film
	std::string points()
	{
		double sum = 0;
		for(auto& x : rating)
		{
			sum = sum + x.rating;
		}
		double media = 0;
		if(rating.size() == 0)
		{
			return "none";
		}
		else  // conversia in string si rotunjirea cu doua zecimale
		{
			media = sum/rating.size();
			media = round(media * 100.0) / 100.0;
			std::stringstream stream;
        	stream << std::fixed << std::setprecision(2) << media;
        	std::string str = stream.str();
		return str;
		}
	}
	double points_int()
	{
		double sum = 0;
		for(auto& x : rating)
		{
			sum = sum + x.rating;
		}
		double media = 0;
		if(rating.size() == 0)
		{
			return -1;
		}
		else
		{
			media = sum / rating.size();
			return media;
		}
	}

	// face conversia unui timestamp in an(int)
	int get_year()
	{
		int year;
		time_t x = timestamp;
		tm global_time;
		gmtime_r(&x, &global_time);
		year = 1900 + global_time.tm_year;

		return year;
	}
};

// clasa in care se memoreaza datele despre actori
class Actor
{
 public:
	std::string id;
	std::string name;
	std::vector <std::string> movie;
	std::vector <int> year;
	std::vector <class Director> director;
	std::vector <std::string> colleagues;

	// functia care returneaza perioada de activitate a unui actor
	int get_career()
	{
		int rez = 0;
		if(year.size() == 0)
		{
			return -1;
		}
		else
		{
			if(year.size() == 1)
			{
				return 0;
			}
			else
			{
				// se sorteaza vectorul de ani
				sort(year.begin(), year.end());
				// se returneaza diferenta dintre ultima si prima pozitie
				rez  = year[year.size() - 1] - year[0];
				return rez;
			}
		}
	}
};

// clasa in care se memoreaza datele despre useri
class User
{
 public:
	std::string id;
	std::string name;
};

#endif
