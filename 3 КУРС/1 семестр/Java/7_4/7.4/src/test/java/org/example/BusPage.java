package org.example;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;


public class BusPage
{
    @FindBy(xpath = "/html/body/div/main/div/div/div/div[1]/div/div[4]/div/select")
    private static WebElement loginBtn;
    public static void clickLoginBtn() {
        loginBtn.click(); }

    public WebDriver driver;
    public BusPage (WebDriver driver)
    {
        PageFactory.initElements(driver, this);
        this.driver = driver; }
}
