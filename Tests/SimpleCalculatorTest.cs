using Calculator;

namespace Tests;

public class SimpleCalculatorTest
{
    [Test]
    public void Add()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 2;
        var b = 3;
        
        // Act
        var result = calc.Add(a, b);
        
        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void Subtract()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 2;
        var b = 1;
        
        // Act
        var result = calc.Subtract(a, b);
        
        // Assert
        Assert.That(result, Is.EqualTo(1));
    }
    
    [Test]
    public void Multiply()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 5;
        var b = 2;
        
        // Act
        var result = calc.Multiply(a, b);
        
        // Assert
        Assert.That(result, Is.EqualTo(10));
    }
    
    [Test]
    public void Divide()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 20;
        var b = 2;
        
        // Act
        var result = calc.Divide(a, b);
        
        // Assert
        Assert.That(result, Is.EqualTo(10));
    }
    
    [Test]
    public void Factorial_ThrowsArgumentException()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = -1;
        
        // Act
        var result = Assert.Throws<ArgumentException>(() => calc.Factorial(n));
        
        // Act & Assert
        Assert.That(result.Message, Is.EqualTo("Factorial is not defined for negative numbers"));
    }
    
    [Test]
    public void Factorial_Returns1()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = 0;
        
        // Act
        var result = calc.Factorial(n);
        
        // Assert
        Assert.That(result, Is.EqualTo(1));
    }
    
    [Test]
    public void Factorial_ReturnsFactorial()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = 5;
        
        // Act
        var result = calc.Factorial(n);
        
        // Assert
        Assert.That(result, Is.EqualTo(120));
    }
    
    [Test]
    public void IsPrime_LessThan2()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var cand = 1;
        
        // Act
        var result = calc.IsPrime(cand);
        
        // Assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void IsPrime_2()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var cand = 2;
        
        // Act
        var result = calc.IsPrime(cand);
        
        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void IsPrime_9()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var cand = 9;
        
        // Act
        var result = calc.IsPrime(cand);
        
        // Assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void IsPrime_ReturnsTrue()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var cand = 7;
        
        // Act
        var result = calc.IsPrime(cand);
        
        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void IsPrime_ReturnsFalse()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var cand = 10;
        
        // Act
        var result = calc.IsPrime(cand);
        
        // Assert
        Assert.That(result, Is.False);
    }
}