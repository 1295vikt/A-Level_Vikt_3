// Принцип инверсии зависимостей - нарушение

class Post
{
    private ErrorLogger errorLogger = new ErrorLogger();

    void CreatePost(Database db, string postMessage)
    {
        try
        {
            db.Add(postMessage);
        }
        catch (Exception ex)
        {
            errorLogger.log(ex.ToString())
        }
    }
}

// Логгер ошибок ErrorLogger создается непосредственно в классе Post
// Если в дальнейшем потребуется использовать другой логгер, то класс Post необходимо будет изменять