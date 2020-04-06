package sample.laba8;

import javafx.fxml.FXML;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;

public class Laba8 {
    @FXML
    TextField cubeBrink;
    @FXML
    TextField rounds;
    @FXML
    Canvas canvas;
    int firstSum = 0;
    int secondSum = 0;
    int brinkNumber;
    int numbOfRounds;
    int count;
    @FXML
    private void start () {
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
        graphicsContext.setFont(Font.font("Times", 30));
        brinkNumber = Integer.parseInt(cubeBrink.getText());
        numbOfRounds = Integer.parseInt(rounds.getText());
        graphicsContext.setFill(Color.RED);
        graphicsContext.fillText("Игра начата: ", 100, 100);
        graphicsContext.setFill(Color.BLACK);
        graphicsContext.fillText("Счет: ", 100, 150);
        graphicsContext.fillText("Игрок 1- " + firstSum + ";    Игрок 2- " + secondSum,  100, 200);
        count = 0;
    }

    @FXML
    private void nextRound () {
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
        if (count  < numbOfRounds) {
            int firstRand = (int) (Math.random() * brinkNumber + 1);
            int secondRand = (int) (Math.random() * brinkNumber + 1);
            firstSum += firstRand;
            secondSum += secondRand;
            graphicsContext.setFill(Color.RED);
            graphicsContext.fillText("Результат броска: ", 100, 100);
            graphicsContext.setFill(Color.BLACK);
            graphicsContext.fillText("Игрок 1- " + firstRand + ";   Игрок 2- " + secondRand, 100, 150);
            graphicsContext.fillText("Счет: ", 100, 200);
            graphicsContext.fillText("Игрок 1- " + firstSum + ";    Игрок 2- " + secondSum, 100, 250);
            count++;
        } else if (count == numbOfRounds) {
            graphicsContext.setFill(Color.RED);
            graphicsContext.fillText("Игра окончена: ", 100, 100);
            graphicsContext.setFill(Color.BLACK);
            graphicsContext.fillText("Результат игры: ", 100, 150);
            graphicsContext.fillText("Игрок 1- " + firstSum + ";  Игрок 2- " + secondSum, 100, 200);
            firstSum = 0;
            secondSum = 0;
        }
    }
}
