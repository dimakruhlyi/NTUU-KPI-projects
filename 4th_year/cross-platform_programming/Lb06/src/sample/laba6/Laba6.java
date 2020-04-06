package sample.laba6;

import javafx.fxml.FXML;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;

public class Laba6 {
    @FXML
    Canvas canvas;
    @FXML
    TextField aField;
    @FXML
    TextField bField;
    @FXML
    TextField cField;
    @FXML
    TextField dField;
    @FXML
    TextField xField;
    @FXML
    TextField yField;
    @FXML
    private void task1() {
        int a = Integer.parseInt(aField.getText());
        int b = Integer.parseInt(bField.getText());
        int c = Integer.parseInt(cField.getText());
        int d = Integer.parseInt(dField.getText());
        int x = Integer.parseInt(xField.getText());
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
//        gridBuild(graphicsContext);
        graphicsContext.setFill(Color.BLACK);
        int max = Math.max(a, b);
        max = Math.max(max, c);
        max = Math.max(max, d);
        graphicsContext.setFont(Font.font("Times", 30));
        graphicsContext.fillText("y = Max(a, b, c, d) = " + max, 400, 350);
        graphicsContext.fillText("y = x^4 = " + (int)Math.pow(x, 4), 400, 400);
        graphicsContext.fillText("y = ax^2 + bx + c = " + (a * x * x + b * x + c), 400, 450);
    }

    @FXML
    private void task2() {
        double a = Integer.parseInt(aField.getText());
        double b = Integer.parseInt(bField.getText());
        double c = Integer.parseInt(cField.getText());
        int d = Integer.parseInt(dField.getText());
        int y = Integer.parseInt(xField.getText());
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
//        gridBuild(graphicsContext);
        graphicsContext.setFill(Color.BLACK);
        graphicsContext.setFont(Font.font("Times", 30));
        graphicsContext.fillText("y = x^4 => x = " + Math.pow(y, 1/4), 400, 350);
        graphicsContext.fillText("y = ax + c => x = " + ((y - c) / a), 400, 400);
        a /= y;
        b /= y;
        c /= y;
        double disc = b * b - 4 * a * c;
        double roundStep = 1000;
        String text = "y = ax^2 + bx + c =>";
        if (disc < 0) {
            text += "Корней нет";
        } else if (disc == 0) {
            double xB = Math.round(((-b) / 2 * a) * roundStep) / roundStep;
            text += "x = " + xB;
        } else {
            double x1B = Math.round((((-b  + Math.sqrt(disc))/ 2 * a)) * roundStep) / roundStep;
            double x2B = Math.round((((-b  - Math.sqrt(disc))/ 2 * a)) * roundStep) / roundStep;
            text += "x1 = " + x1B + "; x2 = " + x2B;
        }
        graphicsContext.fillText(text, 400, 450);
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
