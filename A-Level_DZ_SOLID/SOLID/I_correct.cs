// Принцип разделения интерфейса - исправление

interface IPostCreate
{
    void CreatePost();
}

interface IPostRead
{
    void ReadPost();
}

// Вместо совмещения методов в одном интерфейсе используются отдельные интерфейсы, каждый со своей функцией
