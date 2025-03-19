using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    [Test]
    public void Add()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        var result = calc.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void Add_Cached()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        calc.Add(a, b);
        var result = calc.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void Subtract()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 1;

        // Act
        var result = calc.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }
    
    [Test]
    public void Subtract_Cached()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 1;

        // Act
        calc.Subtract(a, b);
        var result = calc.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }
    
    [Test]
    public void Multiply()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 10;
        var b = 2;

        // Act
        var result = calc.Multiply(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(20));
    }
    
    [Test]
    public void Multiply_Cached()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 10;
        var b = 2;

        // Act
        calc.Multiply(a, b);
        var result = calc.Multiply(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(20));
    }
    
    [Test]
    public void Divide()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 4;
        var b = 2;

        // Act
        var result = calc.Divide(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void Divide_Cached()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 4;
        var b = 2;

        // Act
        calc.Divide(a, b);
        var result = calc.Divide(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void Factorial()
    {
        // Arrange
        var calc = new CachedCalculator();
        var n = 5;
        
        // Act
        var result = calc.Factorial(n);
        
        // Assert
        Assert.That(result, Is.EqualTo(120));
    }
    
    [Test]
    public void Factorial_Cached()
    {
        // Arrange
        var calc = new CachedCalculator();
        var n = 5;

        // Act
        calc.Factorial(n);
        var result = calc.Factorial(n);

        // Assert
        Assert.That(result, Is.EqualTo(120));
    }
    
    [Test]
    public void IsPrime()
    {
        // Arrange
        var calc = new CachedCalculator();
        var cand = 7;
        
        // Act
        var result = calc.IsPrime(cand);
        
        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void IsPrime_Cached()
    {
        // Arrange
        var calc = new CachedCalculator();
        var cand = 7;

        // Act
        calc.IsPrime(cand);
        var result = calc.IsPrime(cand);

        // Assert
        Assert.That(result, Is.True);
    }
}