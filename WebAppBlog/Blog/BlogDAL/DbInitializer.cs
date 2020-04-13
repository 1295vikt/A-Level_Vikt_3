using BlogDAL.Models;
using BlogDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    class DbInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {

            Author a1 = new Author { FirstName = "Vasya", LastName = "Pupkin", Nickname = "Vasilius", Avatar = "~/Resources/vasya.jpg",
                Articles = new List<Article>
                {
                    new Article
                    {
                        Title = "Lorem Ipsum",
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam malesuada varius dignissim. Etiam sagittis orci sit amet nunc condimentum aliquam. Duis ac malesuada ante. Morbi tellus lorem, posuere et malesuada eget, vehicula non urna. Aenean lorem ex, vulputate quis nulla vitae, aliquet sagittis risus. Vivamus hendrerit vestibulum mattis. Suspendisse dui felis, ornare ut fermentum id, rutrum nec nibh. Suspendisse aliquam porttitor tortor eu consectetur. Pellentesque vestibulum diam nec facilisis tincidunt. Duis congue, massa et rutrum imperdiet, mi nulla congue magna, eget rutrum erat ligula vel metus. Phasellus a leo id dolor condimentum tempus. Vivamus feugiat sapien aliquam, vestibulum nunc ac, luctus velit. Nulla scelerisque suscipit massa, at interdum ligula fermentum sit amet. Vestibulum at nulla hendrerit, facilisis risus eget, lobortis dui. Quisque et arcu a ipsum varius varius vel quis quam. Duis ut lorem eu purus gravida vestibulum sed non diam.",
                        Image = "~/Resources/lorem-ipsum.jpg",
                        Date = new DateTime(2020, 4, 10, 7, 15, 32)
                    },
                    new Article
                    {
                        Title = "Generic Article",
                        Body = "Generics allow you to define a class with placeholders for the type of its fields, methods, parameters, etc. Generics replace these placeholders with some specific type at compile time. A generic class can be defined using angle brackets<>.For example, the following is a simple generic class with a generic member variable, generic method and property.",
                        Image = "~/Resources/genericcup.jpg",
                        Date = new DateTime(2020, 4, 11, 14, 4, 02)
                    }
                } 
                };
            Author a2 = new Author { FirstName = "Dimas", LastName = "Dimasov", Nickname = "Dimasovsky", Avatar = "~/Resources/dimas.jpg",
                Articles = new List<Article>
                {
                    new Article
                    {
                        Title = "Me and JS",
                        Body = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHH! AAAAAAAAAAAAAAAAAAAAAAAAAHHHHHH! AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHH!!!",
                        Image = "~/Resources/Jimmy-Barnes-Scream.jpg",
                        Date = new DateTime(2020, 4, 12, 1, 34, 52)
                    }
                }
            };
            Author a3 = new Author
            {
                FirstName = "Murka",
                Nickname = "Moobot",
                Avatar = "~/Resources/murka.jpg",
                Articles = new List<Article>
                {
                    new Article
                    {
                        Title = "Grass",
                        Body = "Mooo moo mooooo mooo mo mooo. Moooooo mooo mooo moooo moo moo mooooo. Moo moooooooo, moo moooooo moooo mooooooooo mooo moooo moooooooo! Moooooo mooooo mooo moooo moo, moo moooo. Moooo moo mooooo mooo moo mooooo. Moo moooooooo, moo moooooo moooo mooooooooo mooo moooo mooooooooooooo. Mooo!",
                        Image = "~/Resources/meadow.jpg",
                        Date = new DateTime(2017, 3, 15, 15, 24, 42)
                    }
                }
            };
            Author a4 = new Author
            {
                FirstName = "NPC",
                Nickname = "NPC",
                Avatar = "~/Resources/npc.jpg",
                Articles = new List<Article>
                {
                    new Article
                    {
                        Title = "Orange Man Bad",
                        Body = "Current year! Drumph! Believe women! Come on, I mean really! Refugees welcome! Misogyny! Transphobia! ORANGE MAN BAD! Trust usssss! Suspendisse interdum purus quis metus cursus, id feugiat enim semper. Donec scelerisque pretium ante sed lacinia. Praesent ac urna nibh. Suspendisse potenti. Quisque id leo et nibh imperdiet feugiat eget id ex. Quisque sit amet faucibus est. Sed viverra, tellus feugiat molestie interdum, est tellus pellentesque risus, ut dignissim lacus augue eget felis.",
                        Image = "~/Resources/OrangeMan.jpg",
                        Date = new DateTime(2018, 8, 2, 12, 42, 42)
                    }
                }
            };

            context.Authors.Add(a1);
            context.Authors.Add(a2);
            context.Authors.Add(a3);
            context.Authors.Add(a4);
            context.SaveChanges();
        }
    }
}