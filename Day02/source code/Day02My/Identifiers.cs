using System;
using static System.Console;


namespace Day02My
{
    /*
     * Shows usage of 'as' and 'is'
     */
    class Identifiers : Section
    {
        public override void runAsync()
        {
            Author author = new Author
            {
                Name = "John"
            };
            TeamMember teamMember = new TeamMember
            {
                Name = "Member"
            };
            ContentMember contentMember = new ContentMember("Content")
            {
                Name = "Content2"
            };
            contentMember.GetContentMemberName();
            new StackHolder().GetAuthorName(author);
            new StackHolder().GetStackholdersName(author);
            new StackHolder().GetStackholdersName(teamMember);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
