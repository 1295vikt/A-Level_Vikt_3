// Принцип подстановки Барбары Лисков  - исправление

class MentionPost : Post
{
    override void CreatePost(Database db, string postMessage)
    {
        string user = ParseUser(postMessage);

        NotifyUser(user);
        OverrideExistingMention(user, postMessage)
        base.CreatePost(db, postMessage);
    }

    private void NotifyUser(string user)
    {
        db.NotifyUser(user);
    }

    private void OverrideExistingMention(string user, string postMessage)
    {
        db.OverrideExistingMention(_user, postMessage);
    }
}

// Класс-наследник изменен, что бы внутри него переопределялся вызываемый метод CreatePost() и не нарушался принцип подстановки