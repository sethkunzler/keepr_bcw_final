public interface IRepo<T>
{
  public List<T> GetAll();
  public T GetById(int id);
  public T Create(T data);
  public T Update(T data);
  public void Destroy(int id);
}