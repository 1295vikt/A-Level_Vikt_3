// Принцип инверсии зависимостей - исправление

class Post
{
    private Logger _logger;

    public Post(Logger injectedLogger)
    {
        _logger = injectedLogger;
    }

    void CreatePost(Database db, string postMessage)
    {
        try
        {
            db.Add(postMessage);
        }
        catch (Exception ex)
        {
            logger.log(ex.ToString())
        }
    }
}

// Вместо создания логгера внутри класса Post передаем его в качестве параметра
// Тем самым класс Post больше не привязан к конкретному логгеру