package sample;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.stage.Stage;

import java.net.URL;

public class Main extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception{

        FXMLLoader loader = new FXMLLoader();
        URL xmlUrl = getClass().getResource("sample.fxml");
        loader.setLocation(xmlUrl);
        Parent root = loader.load();
        primaryStage.setTitle("Пятнашки");
        Scene scene = new Scene(root, 300, 300);
        primaryStage.setScene(scene);
        primaryStage.setResizable(false);
        primaryStage.getIcons().add(new Image("https://yt3.ggpht.com/a/AATXAJw0kw02urkKWfIdCf-8mDyGJJZccl_0BCx-iQ=s900-c-k-c0xffffffff-no-rj-mo"));

        Controller controller = loader.getController();
        controller.setStage(primaryStage);

        primaryStage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
