// Принцип разделения интерфейса - нарушение

interface IPost
{
    void CreatePost();
}

interface IPostNew
{
    void CreatePost();
    void ReadPost();
}


// Предположим изначально существовал интерфейс IPost, который в дальнейшем был изменен и принял вид IPostNew
// Нарушается принцип разделения
// Для всех классов, ранее реализующих только метод CreatePost(), потребуется реализовать и ReadPost()
