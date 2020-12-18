package sample.homeWork8;

import javafx.fxml.FXML;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;

public class HomeWork8 {
    @FXML
    Canvas canvas;
    @FXML
    TextField num;
    boolean firstClick = true;
    int number;
    int tryNumbs = 0;
    @FXML
    private void guess () {
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
        graphicsContext.setFont(Font.font("Times", 30));
        int numb = Integer.parseInt(num.getText());
        if (firstClick) {
            firstClick = false;
            number = (int)(Math.random() * 101);
            System.out.println(number);
        }
        if (numb == number) {
            tryNumbs++;
            graphicsContext.fillText("Количество попыток: " + tryNumbs, 100, 150);
            graphicsContext.setFill(Color.GREEN);
            graphicsContext.fillText("Правильно!", 100, 100);
            firstClick = true;
            tryNumbs = 0;
        } else if (numb > number) {
            tryNumbs++;
            graphicsContext.fillText("Количество попыток: " + tryNumbs, 100, 150);
            graphicsContext.setFill(Color.BLUE);
            graphicsContext.fillText("Меньше", 100, 100);
        } else {
            tryNumbs++;
            graphicsContext.fillText("Количество попыток: " + tryNumbs, 100, 150);
            graphicsContext.setFill(Color.RED);
            graphicsContext.fillText("Больше", 100, 100);
        }
    }

    @FXML
    private void anew () {
        firstClick = true;
        tryNumbs = 0;
    }
}
