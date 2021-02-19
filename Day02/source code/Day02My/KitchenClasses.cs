namespace Day02My
{
    internal class KitchenClasses
    {
    }
    internal class Bacon
    {
    }

    internal class Coffee //internal	Access is limited exclusively to classes defined within the current project assembly - so not public (that would be visible outside of assembly) but also not private
    {
        public string Name { get; set; } = "Mocca"; //init auto-property
    }
    internal class Juice
    {
        public Juice()
        {
            Type = "Orange";
        }

        public string Type { get;} //write read-only auto-property in Constructor (only place to init it)

    }

    internal class Toast
    {
    }

    internal class Egg
    {
    }
}