using System;
using System.Collections.Generic;
using System.Text;

namespace Day02My
{
    //Abstract is a template that needs to be finalized by providing real implementation of things.
    //Abstract is a template for derived classes
    public abstract class Person //ar eyet to complete or missing defintion
    {
        public abstract string Name { get; set; }
        public string duplicateName() => this.Name + " x2";
    }
    public class Author : Person //we can override abstraction to make class real
    {
        public override string Name { get; set; }
    }
    public class Reviewer : Person
    {
        public override string Name { get; set; }
        public Reviewer(string Name)
        {
            this.Name = Name;
        }
    }
    public class TeamMember : Person
    {
        public override string Name { get; set; }
        public void GetMemberName()
        {
            Console.Write($"\nTM Name: {Name}");
        }
    }
    public class ContentMember : TeamMember //we can use methods from a hierarchy explicitely
    {
    
        public ContentMember(string name)
        {
            base.Name = name;
        }
        public new void  GetMemberName()
        {
            Console.Write($"\nCM Name: {Name}");
        }
        public void GetContentMemberName()
        {
            this.GetMemberName(); //if we override the method we can acces it liek this
            base.GetMemberName(); //but we still can access parent one
        }
    }

    public class StackHolder
    {
        public void GetAuthorName(Person person) //function can accept abstract as param
        {
            var author = person as Author; //we cannot call or instantiate abstract but we can use one of implementatioms
            Console.WriteLine(author.Name != null ? $"\nName: {author.Name}" : "No name set");
        }
        public void GetStackholdersName(Person person)
        {
            if (person is Author)
            {
                Console.WriteLine($"\nAuthor Name: {((Author) person).Name}"); //rzutowanie
            }else if(person is TeamMember tm) //new syntax for check and cast
            {
                Console.WriteLine($"\nTeamMember Name: {tm.Name}");
            }
        }
    }
}
