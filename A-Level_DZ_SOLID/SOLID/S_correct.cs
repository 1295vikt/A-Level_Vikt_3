﻿// Принцип единственной ответственности - исправление

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

class ErrorLogger
{
    void log(string error)
    {
        db.LogError("An error occured: ", error);
        File.WriteAllText("\LocalErrors.txt", error);
    }
}

// Логирование ошибок перенесено в отдельный класс ErrorLogger
// В результате имеем два класса с единственной ответственностью