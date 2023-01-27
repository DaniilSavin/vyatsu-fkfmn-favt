package org.example;
import org.junit.BeforeClass;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import java.io.IOException;
import java.util.List;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;


public class BusTest
{
    public BusPage buspage;
    public WebDriver driver;
    @BeforeClass
    public static void main(String[] args) throws IOException
    {

        System.setProperty("webdriver.chrome.driver", ConfProperties.getProperty("chromedriver"));

        WebDriver driver = new ChromeDriver();

        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
        driver.get(ConfProperties.getProperty("loginpage"));

        WebElement stop;
        WebElement bus;
        int [] arr = new int[100];

        for (int i = 2; i <= 64; i++)
        {
            System.out.print(i-1 + ": ");
            bus = driver.findElement(By.xpath("/html/body/div/main/div/div/div/div[1]/div/div[4]/div/select/option[" + i + "]"));
            int n = Integer.parseInt(bus.getAttribute("value"));
            arr[i] = n%1000;
            System.out.println(n % 1000);
        }

        System.out.println("Выберите номер автобуса: ");
        Scanner inp = new Scanner(System.in);
        int k = inp.nextInt();

        System.out.println("Остановки для автобуса " + arr[k+1] +": ");
        System.out.println("-------------------------------");
        driver.findElement(By.xpath("/html/body/div/main/div/div/div/div[1]/div/div[4]/div/select/option["+(k+1)+"]")).click();
        for (int i = 1; i <= 62; i++)
        {
            stop = driver.findElement(By.xpath("/html/body/div/main/div/div/div/div[2]/div[1]/div[4]/img[" + i + "]"));
            System.out.println(stop.getAttribute("title"));
            System.out.println("-------------------------------");
        }

    }

}
