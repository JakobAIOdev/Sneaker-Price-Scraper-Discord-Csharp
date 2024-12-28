class PayPal
{
    public float InputPrice { get; set; }
    public float OutputPrice { get; set; }

    public PayPal(float inputPrice)
    {
        InputPrice = inputPrice;
    }

    public float CalculateFees()
    {
        OutputPrice = (InputPrice * 0.0249f) + 0.35f;
        return OutputPrice;
    }

    public float CalculatePayout()
    {
        OutputPrice = InputPrice - CalculateFees();
        return OutputPrice;
    }
}