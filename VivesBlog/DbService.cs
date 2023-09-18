﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VivesBlog;
public class DbService
{
    private readonly DB _database;

    public DbService(DB database)
    {
        _database = database;
    }

    public IList<Article> GetArticles()
    {
        return _database.Articles
            .Include(a => a.Author)
            .ToList();
    }

    public Article GetArticle(int id)
    {
        return _database.Articles
            .Include(a => a.Author)
            .SingleOrDefault(a => a.Id == id);
    }

    public IList<Person> GetPeople()
    {
        return _database.People.ToList();
    }

    public void AddPerson(Person person)
    {
        _database.People.Add(person);
        _database.SaveChanges();
    }

    public Person UpdatePerson(int id, Person person)
    {
        return _database.People.Single(p => p.Id == id);
    }

    public Person GetPerson(int id)
    {
        return _database.People.Single(p => p.Id == id);
    }

    public void DeletePerson(int id)
    {
        var dbPerson = _database.People.Single(p => p.Id == id);

        _database.People.Remove(dbPerson);

        _database.SaveChanges();
    }

    public void AddArticle(Article article)
    {
        article.CreatedDate = DateTime.Now;

        _database.Articles.Add(article);

        _database.SaveChanges();
    }

    public Article UpdateArticle(int id, Article article)
    {
        var dbArticle = _database.Articles.Single(p => p.Id == id);

        dbArticle.Title = article.Title;
        dbArticle.Description = article.Description;
        dbArticle.Content = article.Content;
        dbArticle.AuthorId = article.AuthorId;

        _database.SaveChanges();

        return dbArticle;
    }

    public void DeleteArticle(int id)
    {
        var dbArticle = _database.Articles.Single(p => p.Id == id);

        _database.Articles.Remove(dbArticle);

        _database.SaveChanges();
    }

    public IList<Person> GetPeopleOrderd()
    {
        return _database.People
            .OrderBy(a => a.Name1)
            .ThenBy(a => a.Name2)
            .ToList();
    }
}