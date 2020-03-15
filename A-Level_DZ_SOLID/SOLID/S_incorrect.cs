// Принцип единственной ответственности - нарушение

class User
{
    void CreatePost(Database db, string postMessage)
    {
        try
        {
            db.Add(postMessage);
        }
        catch (Exception ex)
        {
            db.LogError("An error occured: ", ex.ToString());
            File.WriteAllText("\LocalErrors.txt", ex.ToString());
        }
    }
}

// Класс User имеет слишком много ответственности.
// Метод CreatePost отвечает оновременно за создание нового поста, запись лога ошибки в базу данных и в локальный файл