// Принцип открытости / закрытости - исправление

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

// Функционал класса Post расширен путем наследования
// Определение необходимого первого символа может выполняться в другом месте (на более высоком уровне)
