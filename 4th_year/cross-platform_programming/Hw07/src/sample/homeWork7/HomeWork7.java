package sample.homeWork7;

import javafx.animation.AnimationTimer;
import javafx.fxml.FXML;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.Spinner;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import sample.Dot;

import java.util.ArrayList;
import java.util.PriorityQueue;

public class HomeWork7 {
    @FXML
    TextField num;
    @FXML
    Canvas canvas;
    @FXML
    private void task1 () {
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
        //gridBuild(graphicsContext);
        int numb = Integer.parseInt(num.getText());
        int [] fibbon = new int[numb];
        fibbon[0] = 0;
        fibbon[1] = 1;
        for (int i = 2; i < numb; i++) {
            fibbon[i] = fibbon[i - 1] + fibbon[i - 2];
        }
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

    private static final int HEAD_WIDTH = 400;
    private static final int HEAD_HEIGHT = 400;
    private static final int EYE_RADIUS = 50;
    private static final int MOUTH_WIDTH = 300;
    private static final int MOUTH_HEIGHT = 100;
    @FXML
    private void task2 () {
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
        //gridBuild(graphicsContext);
        graphicsContext.setStroke(Color.BLACK);
        graphicsContext.setLineWidth(3);
        graphicsContext.strokeRect(300, 150, HEAD_WIDTH, HEAD_HEIGHT);
        graphicsContext.strokeOval(350, 200, EYE_RADIUS * 2, EYE_RADIUS * 2);
        graphicsContext.strokeOval(550, 200, EYE_RADIUS * 2, EYE_RADIUS * 2);
        graphicsContext.strokeRect(350, 400, MOUTH_WIDTH, MOUTH_HEIGHT);
        int x = 400;
        for (int i = 0; i < 5; i++) {
            graphicsContext.strokeLine(x, 400, x, 500);
            x += 50;
        }
        graphicsContext.strokeRect(350, 50, 100, 100);
        graphicsContext.strokeRect(550, 50, 100, 100);
        graphicsContext.setFont(Font.font("Times", 40));
        graphicsContext.fillText("Заяц-Волк,", 750, 150);
        graphicsContext.fillText("Заяц-Волк", 750, 200);

    }

    @FXML
    Spinner nail1;
    @FXML
    TextField numb;
    Nail nail;
    Nail nai2;
    Nail nai3;
    int numberOfDisks;
    GraphicsContext graphicsContext;
    int spNail;
    @FXML
    private void task3 () {
        numberOfDisks = Integer.parseInt(numb.getText());
        graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1492, 768);
        graphicsContext.setFill(Color.BLACK);
//        gridBuild(graphicsContext);
        graphicsContext.setStroke(Color.BLACK);
        nail = new Nail(graphicsContext, numberOfDisks, new Dot(50, 700), new Dot(150, 700));
        nai2 = new Nail(graphicsContext, 0, new Dot(450, 700), new Dot(550, 700));
        nai3 = new Nail(graphicsContext, 0, new Dot(950, 700), new Dot(1050, 700));
        nail.draw();
        nai2.draw();
        nai3.draw();
    }

    AnimationTimer animationTimer = new AnimationTimer() {
        @Override
        public void handle(long now) {
            anim();
        }
    };
    ArrayList <Integer> operations;
    @FXML
    private void runAlg () {
        spNail = (int)nail1.getValue();
        operations = new ArrayList<>();
        operations.add(1);
        operations.add(2);
        for (int i = 0; i < numberOfDisks - 1; i++) {
            if (i % 2 == 0) {
                operations.add(1);
                operations.add(3);
                operations.add(2);
                operations.add(3);
            } else {
                operations.add(1);
                operations.add(2);
                operations.add(3);
                operations.add(2);
            }
        }
        if (spNail == 3) {
            operations.add(2);
            operations.add(3);
        }
        animationTimer.start();
    }
    int left = 1;

    public void anim () {
        if (left == 1) {
            if (operations.isEmpty()) {
                animationTimer.stop();
                return;
            }
            int sn = operations.get(0);
            operations.remove(0);
            int pol = operations.get(0);
            operations.remove(0);
            if (sn == 1 && pol == 2) {
                nai2.addDisk(nail.getDisk());
            } else if (sn == 1 && pol == 3) {
                nai3.addDisk(nail.getDisk());
            } else if (sn == 2 && pol == 3) {
                while (!nai2.isEmpty()) {
                    nai3.addDisk(nai2.getAll());
                }
            } else if (sn == 3 && pol == 2) {
                while (!nai3.isEmpty()) {
                    nai2.addDisk(nai3.getAll());
                }
            }
            graphicsContext.setFill(Color.WHITE);
            graphicsContext.fillRect(0, 0, 1492, 768);
            graphicsContext.setFill(Color.BLACK);
            nail.draw();
            nai2.draw();
            nai3.draw();
            left++;
        } else if (left == 50) {
            left = 1;
        } else {
            left ++;
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
