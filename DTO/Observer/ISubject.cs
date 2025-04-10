
namespace Observer
{
	public interface ISubject
	{
		void RegistrarObser(IObserver observer);
		void RemoverObserver(IObserver observer);
		void NotificarObservers(string message);
	}
}

