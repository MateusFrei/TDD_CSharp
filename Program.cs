class Program
{
    static void Main()
    {
        // Exemplo de vetor com faturamento diário (valores fictícios)
        double[] faturamentoDiario = { 100, 200, 0, 300, 150, 0, 0, 500, 0, 600, 0, 0, 250, 0, 1000, 0, 100, 0, 700, 0, 400, 0, 0, 800, 0, 0, 0, 900, 0, 300 };

        if (faturamentoDiario == null || faturamentoDiario.Length == 0)
        {
            Console.WriteLine("Vetor de faturamento está vazio ou nulo.");
            return;
        }

        var resultado = CalcularFaturamento(faturamentoDiario);

        Console.WriteLine($"Menor faturamento: {resultado.Item1}");
        Console.WriteLine($"Maior faturamento: {resultado.Item2}");
        Console.WriteLine($"Dias acima da média anual: {resultado.Item3}");
    }

    static (double, double, int) CalcularFaturamento(double[] faturamentoDiario)
    {
        double menorFaturamento = faturamentoDiario.Where(f => f > 0).DefaultIfEmpty(double.MaxValue).Min();
        double maiorFaturamento = faturamentoDiario.Where(f => f > 0).DefaultIfEmpty(double.MinValue).Max();

        double somaFaturamento = faturamentoDiario.Where(f => f > 0).Sum();
        int diasComFaturamento = faturamentoDiario.Count(f => f > 0);

        double mediaAnual = diasComFaturamento > 0 ? somaFaturamento / diasComFaturamento : 0;

        int diasAcimaDaMedia = faturamentoDiario.Count(f => f > mediaAnual);

        return (menorFaturamento, maiorFaturamento, diasAcimaDaMedia);
    }
}