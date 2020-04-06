package sample.laba7;

import javafx.fxml.FXML;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;

public class Laba7 {
    @FXML
    Canvas canvas;
    @FXML
    TextField num;
    @FXML
    TextField factNum;
    @FXML
    private void task1() {
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
        //gridBuild(graphicsContext);
        int numb = Integer.parseInt(num.getText());
        int [] fibbon = new int[numb];
        fibbon[0] = 0;
        fibbon[1] = 1;
        fibbon = fibbonachi(2, numb, fibbon);
        graphicsContext.setFont(Font.font("Times", 20));
        int x = 50;
        int y = 50;
        for (int i = 0; i < numb; i++) {
            graphicsContext.fillText("" + fibbon[i] + "; ", x, y);
            x += 50;
            if (x >= 1100) {
                y += 50;
                x = 50;
            }
        }
    }

    private int [] fibbonachi (int i, int numb, int [] fibbon) {
        if (i == numb) {
            return fibbon;
        } else {
            fibbon[i] = fibbon[i - 1] + fibbon[i - 2];
            return fibbonachi(i + 1, numb, fibbon);
        }
    }

    @FXML
    private void task2() {
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
        int factorialNumb = Integer.parseInt(factNum.getText());
        int factorial = fact(1, factorialNumb);
        graphicsContext.setFont(Font.font("Times", 20));
        graphicsContext.fillText("" + factorialNumb + "! = " + factorial, 100, 100);
    }

    private int fact (int factorial, int numb) {
        if (numb == 1) {
            return factorial;
        } else {
            return fact(factorial * numb, numb - 1);
        }
    }

    @FXML
    TextField number;
    @FXML
    private void task3 () {
        int numb = number(0, Integer.parseInt(number.getText()));
        if (Integer.parseInt(number.getText()) == 0) {
            numb = 1;
        }
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
        graphicsContext.setFont(Font.font("Times", 20));
        graphicsContext.fillText("Число " + number.getText() + " состоит из " + numb + " цифр", 100, 100);
    }

    private int number (int numb, int number) {
        if (number == 0) {
            return numb;
        } else {
            return number(numb + 1, (number / 10));
        }
    }

    private void gridBuild(GraphicsContext graphicsContext) {
        graphicsContext.setLineWidth(1);
        for (int x = 0; x < 1300; x += 50) {
            graphicsContext.setStroke(Color.LIGHTCORAL);
            graphicsContext.strokeLine(x, 0, x, 768);
            graphicsContext.setStroke(Color.GRAY);
            graphicsContext.setFont(Font.font("Times", 10));
            graphicsContext.strokeText(("" + (x)), (x + 2), 10);
        }

        for (int y = 0; y < 750; y += 50) {
            graphicsContext.setStroke(Color.LIGHTCORAL);
            graphicsContext.strokeLine(0, y, 1305, y);
            graphicsContext.setStroke(Color.GRAY);
            graphicsContext.setFont(Font.font("Times", 10));
            graphicsContext.strokeText(("" + (y)), 10, (y - 2));
        }
    }
}
