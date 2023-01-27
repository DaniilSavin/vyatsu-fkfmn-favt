package sample;

import Pyatnashki.*;
import javafx.animation.AnimationTimer;
import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.Cursor;
import javafx.scene.control.*;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.*;
import javafx.stage.Stage;
import java.time.Duration;


public class Controller {

    @FXML
    private MenuBar menuBar;

    @FXML
    private Menu menu;

    @FXML
    private AnchorPane actionPane;

    @FXML
    private GridPane gridPane;

    @FXML
    private Button restoreButton;

    @FXML
    private MenuItem newGame;

    @FXML
    private MenuItem exit;

    @FXML
    private Label statusLabel;

    @FXML
    private Label timeLabel;

    private final int size = 4;
    private Pyatnashki game;
    private int count = 0;
    private long lastTickTime;
    private AnimationTimer timer;

    @FXML
    private void onClickExitItem(){
        Platform.exit();
    }
    @FXML
    private void onClickNewGameItem(){
        game.generate(GUI2.numbers);
        repaintField();
        count = 0;
        statusLabel.setText("Ход: " + count);
        lastTickTime = System.currentTimeMillis();
        timer.start();
    }
    @FXML
    private void onClickRestoreButton() {
        restore();
    }

    @FXML
    private void initialize() {
        game = new Pyatnashki();

        statusLabel.setText("Ход: " + count);
        lastTickTime = System.currentTimeMillis();
        timeLabel.setText(String.format("%04d:%02d:%02d.%03d", 0, 0, 0, 0));
        timer = new AnimationTimer() {
            @Override
            public void handle(long l) {
                long runningTime = System.currentTimeMillis() - lastTickTime;
                Duration duration = Duration.ofMillis(runningTime);
                long millis = duration.toMillis();
                long seconds = millis / 1000;
                millis -= (seconds * 1000);
                timeLabel.setText(String.format(" %01d:%02d:%02d", duration.toHours(), duration.toMinutes() % 60, seconds % 60));
            }
        };

        timer.start();

        createGridPane();
        game.generate(GUI2.numbers);
        repaintField();

    }

    private void restore(){
        if (count > 0){
            game.Cancel();
            statusLabel.setText("Ход: " + --count);
            repaintField();
        }
    }

    private Button getButton(String text){

        Button button = new Button();
        button.setMaxWidth(Double.MAX_VALUE);
        button.setMaxHeight(Double.MAX_VALUE);
        button.setText(text);
        button.setFocusTraversable(false);
        button.setCursor(Cursor.HAND);
        button.setStyle("-fx-font: 22 arial; -fx-base: #fff;");

        return button;
    }

    private void repaintField() {
        gridPane.getChildren().clear();
        int[][]field = GUI2.numbers;
        for (int j = 0; j < size; j++)
            for (int i = 0; i < size; i++) {
                Button button = getButton(Integer.toString(field[j][i]));
                gridPane.add(button, i, j);
                if (field[j][i] == 0){
                    button.setVisible(false);
                }
                else
                    {
                    button.setOnAction(new EventHandler1());
                }
            }


    }
    private void createGridPane()
    {
        for (int i = 0; i < size; ++i)
        {
            ColumnConstraints column = new ColumnConstraints();
            column.setHgrow(Priority.SOMETIMES);
            column.setMinWidth(50);
            column.setPrefWidth(70);
            gridPane.getColumnConstraints().add(column);

            RowConstraints row = new RowConstraints();
            row.setVgrow(Priority.SOMETIMES);
            row.setMinHeight(10);
            row.setPrefHeight(30);
            gridPane.getRowConstraints().add(row);
        }


    }

    private class EventHandler1 implements EventHandler<ActionEvent> {
        @Override
        public void handle(ActionEvent actionEvent) {
            Button button = (Button) actionEvent.getSource();
            String name = button.getText();
            GUI2.saves.Save(new Memento(GUI2.numbers));

            button.setVisible(false);

            Pyatnashki.change(Integer.parseInt(name));
            statusLabel.setText("Ход: " + ++count);
            repaintField();

        }
    }
    Stage stage;

    public void setStage(Stage stage) {
        this.stage = stage;
        stage.addEventHandler(KeyEvent.KEY_PRESSED, event -> {
            if (event.getCode() == KeyCode.Z && event.isShortcutDown()) {
                restore();
            }
        });
    }

}
