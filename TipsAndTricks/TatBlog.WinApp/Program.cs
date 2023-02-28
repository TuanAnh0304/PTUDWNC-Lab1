﻿using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;

var context = new BlogDbContext();

var seeder = new DataSeeder(context);

seeder.Initialize();

var authors = context.Author.ToList();

var posts = context.Posts
    .Where(p => p.Published)
    .OrderBy(p => p.Title)
    .Select(p => new
    {
        id = p.Id,
        title = p.Title,
        ViewCount = p.ViewCount,
        PosterDate = p.PostedDate,
        Author = p.Author.FullName,
        Category = p.Category.Name
    })
    .ToList();

foreach (var post in posts)
{
    Console.WriteLine("ID       : {0}", post.id);
    Console.WriteLine("Title    : {0}", post.title);
    Console.WriteLine("View     : {0}", post.ViewCount);
    Console.WriteLine("Date     : {0:MM/dd/yyyy}", post.PosterDate);
    Console.WriteLine("Author   : {0}", post.Author);
    Console.WriteLine("Category : {0}", post.Category);
    Console.WriteLine("".PadRight(80, '-'));

}
Console.WriteLine("{0.-4}{1.-30}{2.-30}{3.12}", "ID", "Full Name", "Email", "Joined Date");

foreach (var author in authors)
{
    Console.WriteLine("{0.-4}{1.-30}{2.-30}{3.12:MM/dd/yyyy}", author.Id, author.FullName, author.Email, author.JoinedDate);
}