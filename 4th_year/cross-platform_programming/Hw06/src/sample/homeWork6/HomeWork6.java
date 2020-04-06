package sample.homeWork6;

import javafx.fxml.FXML;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import sample.Dot;

import java.util.ArrayList;

public class HomeWork6 {
    @FXML
    Canvas canvas;
    @FXML
    TextField cell;
    @FXML
    TextField field;
    @FXML
    TextField interval;
    @FXML
    TextField beeper;

    private int cellSize;
    private int fieldSize;

    @FXML
    private void task1 () {
        ArrayList <Cell> cells = new ArrayList<>();
        cellSize = Integer.parseInt(cell.getText());
        fieldSize = Integer.parseInt(field.getText());
        int cellInLine = Math.round(fieldSize / cellSize);
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        //gridBuild(graphicsContext);
        Cell [] cb = new Cell[cellInLine];
        for (int j = 0; j < cellInLine; j++) {
            for (int i = 0; i < cellInLine; i++) {
                cb[i] = new Cell(new Dot(i * cellSize, j * cellSize), cellSize);
                //cells.add(new Cell(new Dot(i * cellSize, j * cellSize), cellSize));
            }
            if (j % 2 == 1) {
                Cell cellB = cb[cb.length - 1];
                for (int i = cb.length - 1; i > 0 ; i--) {
                    cb[i] = cb[i - 1];
                }
                cb[0] = cellB;
            }
            for (int i = 0; i < cb.length; i++) {
                cells.add(cb[i]);
            }
        }
        for (int i = 0; i < cells.size(); i++) {
            if (i % 2 == 0) {
                graphicsContext.setFill(Color.WHITE);
            } else {
                graphicsContext.setFill(Color.BLACK);
            }
            graphicsContext.fillRect(cells.get(i).startDot.x, cells.get(i).startDot.y, cells.get(i).width, cells.get(i).heigth);
        }
        for (int x = 0; x < fieldSize + cellSize; x += cellSize) {
            graphicsContext.setStroke(Color.BLACK);
            graphicsContext.strokeLine(x, 0, x, fieldSize);
        }
        for (int y = 0; y < fieldSize + cellSize; y += cellSize) {
            graphicsContext.setStroke(Color.BLACK);
            graphicsContext.strokeLine(0, y, fieldSize, y);
        }
    }

    @FXML
    private void task2 () {
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
        //gridBuild(graphicsContext);
        int inter = Integer.parseInt(interval.getText());
        int beep = Integer.parseInt(beeper.getText());
        double [] xst = {beep / 2, 0, beep / 2, beep};
        double [] yst = {0, beep / 2, beep, beep / 2};
        int k = 0;
        double[] x = {beep / 2, 0, beep / 2, beep};
        double[] y = {0, beep / 2, beep, beep / 2};
        while (k < 50) {
            for (int i = 0; i < 50; i++) {
                int red = (int) (Math.random() * 256);
                int green = (int) (Math.random() * 256);
                int blue = (int) (Math.random() * 256);
                graphicsContext.setFill(Color.rgb(red, green, blue));
                graphicsContext.fillPolygon(x, y, 4);
                for (int j = 0; j < y.length; j++) {
                    y[j] += beep;
                }
            }
            for (int i = 0; i < x.length; i++) {
                x[i] = xst[i];
                y[i] = yst[i];
            }
            for (int i = 0; i < x.length; i++) {
                x[i] += (beep + inter) * k;
            }
            k++;
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
