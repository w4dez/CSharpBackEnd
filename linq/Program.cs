using System.IO.Compression;
using System.Reflection;
using Microsoft.VisualBasic;

public class Programm
{

    static void Main()
    {
        /* string[] names = { "Hannah", "Isaac", "Jack", "Anna", "Ben", "Eva",
        "Frank", "Clara", "David", "Grace", "Karen" };

        Console.WriteLine("List of names:"); */

        /*     var namesStartingWithA = names
            .Where(name => name.StartsWith("A"))
            .OrderBy(name => name)
            .ToList();
            foreach (var name in namesStartingWithA)
            {
              Console.WriteLine(name);
            } 
        /* var sortedNames = names
            .OrderBy(name => name)
            .ToList();
        foreach (var name in sortedNames)
        {
          Console.WriteLine(name);
        } */

        /*     var countedNames = names
            .Count(name => name.Length > 4);
            foreach (var name in names)

             {
       Console.WriteLine(name);        
      */

        /*     var length = names.Max(name => name.Length);

            var biggest = names.FirstOrDefault(name => name.Length == length);
            Console.WriteLine(biggest); */
        //Find all names that end with the letter 'a'.
        /*    var allNamesWithA = names
           .Where(name => name.Contains('a'))
           .OrderBy(name => name)
           .ToList();
           foreach (var name in allNamesWithA)
           {
             Console.WriteLine(name);
           } */

        //Find all names with exactly 3 letters.
        /*     var namesWithThreeLetters = names
            .Where(name => name.Length == 3)
            .ToList();
            foreach (string name in namesWithThreeLetters)
            {
              Console.WriteLine(name);
            } */
        ///Find all names longer than 5 characters.
        /*     var longname = names
            .Where(name => name.Length > 5)
            .ToList();
            foreach (string name in longname)
            {
              Console.WriteLine(name);
            }
         */
        //Find all names that start with a vowel (A, E, I, O, U).
        /*     var vowels = new[] { 'A', 'E', 'I', 'O', 'U' };
            var namesThatStartWith = names
            .Where(name => vowels.Contains(name[0]))
            .OrderBy(name => name)
            .ToList();
            foreach (string name in namesThatStartWith)
            {
              Console.WriteLine(name);
            }
         */
        //Find all names that do NOT start with 'J'.
        /*     var nameHaveNoJ = names
            .Where(name => !name.StartsWith('J'))
            .OrderBy(name => name)
            .ToList();
            foreach (string name in nameHaveNoJ)
            {
              Console.WriteLine(name);
            }  */
        //Sort the names by length (shortest first).
        Publisher nintendo = new Publisher { Id = 1, Name = "Nintendo" };
        Publisher cdProjekt = new Publisher { Id = 2, Name = "CD Projekt" };
        Publisher fromSoftware = new Publisher { Id = 3, Name = "FromSoftware" };

        Developer nintendoEPD = new Developer { Id = 1, Name = "Nintendo EPD", Country = "Japan" };
        Developer cdProjektRed = new Developer { Id = 2, Name = "CD Projekt Red", Country = "Poland" };
        Developer fromSoftwareDev = new Developer { Id = 3, Name = "FromSoftware", Country = "Japan" };

        // Die Liste der Spiele
        var games = new List<Game>
{
    new Game
    {
        Id = 1,
        Title = "The Legend of Zelda: Breath of the Wild",
        Developer = nintendoEPD,
        Publisher = nintendo,
        ReleaseDate = new DateTime(2017, 3, 3),
        Reviews = new List<Review>
        {
            new Review { ReviewerName = "IGN", Score = 10 },
            new Review { ReviewerName = "GameSpot", Score = 10 },
            new Review { ReviewerName = "UserA", Score = 9 }
        }
    },
    new Game
    {
        Id = 2,
        Title = "The Witcher 3: Wild Hunt",
        Developer = cdProjektRed,
        Publisher = cdProjekt,
        ReleaseDate = new DateTime(2015, 5, 19),
        Reviews = new List<Review>
        {
            new Review { ReviewerName = "IGN", Score = 9 },
            new Review { ReviewerName = "PC Gamer", Score = 9 },
            new Review { ReviewerName = "UserB", Score = 10 }
        }
    },
    new Game
    {
        Id = 3,
        Title = "Elden Ring",
        Developer = fromSoftwareDev,
        Publisher = fromSoftware,
        ReleaseDate = new DateTime(2022, 2, 25),
        Reviews = new List<Review>
        {
            new Review { ReviewerName = "IGN", Score = 10 },
            new Review { ReviewerName = "GameSpot", Score = 10 },
            new Review { ReviewerName = "UserC", Score = 10 }
        }
    },
    new Game
    {
        Id = 4,
        Title = "Cyberpunk 2077",
        Developer = cdProjektRed,
        Publisher = cdProjekt,
        ReleaseDate = new DateTime(2020, 12, 10),
        Reviews = new List<Review>
        {
            new Review { ReviewerName = "IGN", Score = 7 },
            new Review { ReviewerName = "PC Gamer", Score = 8 },
            new Review { ReviewerName = "UserD", Score = 6 }
        }
    }
};
        //Challenge 1: Simple Filtering - Find all games published by "CD Projekt" and output only their titles.

        var sortGames = games
    .Where(game => game.Publisher.Name == "CD Projekt")
    .OrderBy(game => game.Title);
        foreach (var game in sortGames)
        {
            // Console.WriteLine(game.Title);
            //Console.WriteLine(game.Developer?.Country);
            // Console.WriteLine(game.Publisher?.Name);
        }
        //Challenge 2: Filtering by a Nested Property - Find all games whose developer is from "Japan".
        var sortedByCountry = games
        .Where(game => game.Developer.Country == "Japan")
        .OrderBy(game => game.Title);
        foreach (var game in sortedByCountry)
        {
            /* Console.WriteLine(game.Title);
            Console.WriteLine(game.Developer.Country);
            Console.WriteLine(game.Publisher.Name);
            Console.WriteLine(); */
        }
        ;
        //Challenge 3: Working with Lists - Find all games that received a score of exactly 10 points from "IGN".
        var result = games
    .Where(game => game.Reviews.Any(r => r.ReviewerName == "IGN" && r.Score == 10))
    .ToList();
        foreach (var game in result)
        {
            Console.WriteLine(game.Title);
        }
        //Challenge 4: Projection (Select) with Calculations - Create a new list of objects that contains only the game's title and its average score. Hint: The Reviews list has an Average() method that you can apply to the Score property.
        var sortAverage = games
    .Select(game => new Select
    {
        Title = game.Title,
        AverageScore = game.Reviews.Average(r => r.Score)
    })
    .ToList();
        foreach (var item in sortAverage)
        {
            //Console.WriteLine($"{item.Title}: {item.AverageScore:F1}");
        }

        //Challenge 5: Sorting (OrderBy) - Based on Nested Data Sort all games by the name of their developer (alphabetically).
        var sortAphabetically = games
    .OrderBy(game => game.Developer.Name)
    .ToList();

        foreach (var game in sortAphabetically)
        {
            //Console.WriteLine($"{game.Developer.Name} - {game.Title}");
        }
        // .
        //Challenge 6: Complex Combined Query - Find the titles of all games that were released after January 1, 2018, AND have an average rating of 9 or higher. Sort the result in descending order by the release date.
        var sortedComplex = games
            .Where(game =>
                game.ReleaseDate > new DateTime(2018, 1, 1) &&
                game.Reviews.Average(r => r.Score) >= 9)
            .OrderByDescending(game => game.ReleaseDate)
            .Select(game => game.Title)
            .ToList();

        foreach (var title in sortedComplex)
        {
            Console.WriteLine(title);
        }
    }
}

