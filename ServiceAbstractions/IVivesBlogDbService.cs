using VivesBlog.Models;

namespace VivesBlog.Services;

public interface IVivesBlogDbService
{
    IList<Article> GetArticles();
    Article? GetArticle(int id);
    IList<Person> GetPeople();
    void AddPerson(Person person);
    Person? UpdatePerson(int id, Person person);
    Person? GetPerson(int id);
    void DeletePerson(int id);
    void AddArticle(Article article);
    Article? UpdateArticle(int id, Article article);
    void DeleteArticle(int id);
    IList<Person> GetPeopleOrdered();
}