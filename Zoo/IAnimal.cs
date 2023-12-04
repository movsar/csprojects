namespace Zoo
{
    internal interface IAnimal
    {
        public string Name { get; set; }
        public decimal Age { get; set; }
        public void Move();
    }
}
