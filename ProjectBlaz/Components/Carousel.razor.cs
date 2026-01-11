namespace ProjectBlaz.Components
{
    public partial class Carousel
    {
        private int _currentIndex = 0;

        private List<string> _images = new List<string>
        {
            "/lion.jpg",
            "/koala.webp",
            "/red-panda.jfif",
        };

        private void PrevSlide()
        {
            _currentIndex = (_currentIndex - 1 + _images.Count) % _images.Count;
        }

        private void NextSlide()
        {
            _currentIndex = (_currentIndex + 1 + _images.Count) % _images.Count;
        }

        private void GoToSlide(int index)
        {
            _currentIndex = index;
        }
    }
}
