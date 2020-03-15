// Принцип подстановки Барбары Лисков  - нарушение

class Post
{
    void CreatePost(Database db, string postMessage)
    {
        db.Add(postMessage);
    }
}

class TagPost : Post
{
    override void CreatePost(Database db, string postMessage)
    {
        db.AddAsTag(postMessage);
    }
}

class MentionPost : Post
{
    void CreateMentionPost(Database db, string postMessage)
    {
        string user = ParseUser(postMessage);

        db.NotifyUser(user);
        db.OverrideExistingMention(user, postMessage);
        base.CreatePost(db, postMessage);
    }
}

class PostHandler
{
    private database = new Database();

    void HandleNewPosts()
    {
        List<string> newPosts = database.getUnhandledPostsMessages();

        foreach (string postMessage in newPosts)
        {
            Post post;

            if (postMessage.StartsWith("#"))
            {
                post = new TagPost();
            }
            else if (postMessage.StartsWith("@"))
            {
                post = new MentionPost();
            }
            else
            {
                post = new Post();
            }

            post.CreatePost(database, postMessage);
        }
    }
}

// У класса-наследника MentionPost вместо переопределения метода CreatePost() имеется отдельный внутренний метод
// При вызове этого метода обработчиком PostHandler вместо требуемого результата будет вызван метод класса-родителя