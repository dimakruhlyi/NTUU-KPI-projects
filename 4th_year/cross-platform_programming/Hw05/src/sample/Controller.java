package sample;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.control.TextField;

import java.util.ArrayList;

public class Controller{
    public class Dot {
        public double x;
        public double y;

        public Dot () {

        }

        public Dot (double x, double y) {
            this.x = x;
            this.y = y;
        }
    };
    private ArrayList <Dot> circleDots;
    @FXML
    private Canvas canvas;
    @FXML
    TextField num;
    @FXML

    private void draw () {
        GraphicsContext graphicsContext = canvas.getGraphicsContext2D();
        graphicsContext.setFill(Color.WHITE);
        graphicsContext.fillRect(0, 0, 1920, 1080);
        //gridBuild(graphicsContext);
        helloWorld(graphicsContext);
        drawHouse(graphicsContext);
        sun(graphicsContext);
    }

    public static void gridBuild(GraphicsContext graphicsContext) {
        graphicsContext.setLineWidth(1);
        for (int x = 0; x < 1920; x += 20) {
            graphicsContext.setStroke(Color.GRAY);
            graphicsContext.strokeLine(x, 0, x, 1080);
            graphicsContext.setStroke(Color.GRAY);
            graphicsContext.setFont(Font.font("Times", 10));
            graphicsContext.strokeText(("" + (x)), (x + 2), 10);
        }

        for (int y = 0; y < 1080; y += 20) {
            graphicsContext.setStroke(Color.GRAY);
            graphicsContext.strokeLine(0, y, 1920, y);
            graphicsContext.setStroke(Color.GRAY);
            graphicsContext.setFont(Font.font("Times", 10));
            graphicsContext.strokeText(("" + (y)), 10, (y - 2));
        }
    }

    public static void helloWorld(GraphicsContext graphicsContext){
        graphicsContext.setFill(Color.BLUE);
        graphicsContext.setFont(Font.font ("Verdana", FontWeight.BOLD, 40));
        graphicsContext.fillText("Hello World!", 600, 100);
    }

    public static void drawHouse(GraphicsContext graphicsContext){
        graphicsContext.setFill(Color.CORAL);
        graphicsContext.fillRect(500, 600, 500, 300);
        //Door
        graphicsContext.setFill(Color.BROWN);
        graphicsContext.fillRect(700, 720, 100, 180);
        graphicsContext.setFill(Color.BLACK);
        graphicsContext.fillOval(705,800,20,20);
        //Windows
        graphicsContext.setFill(Color.LIGHTBLUE);
        graphicsContext.fillRect(550, 700, 100, 100);
        graphicsContext.setStroke(Color.BLACK);
        graphicsContext.strokeLine(600,700,600,800);
        graphicsContext.strokeLine(550,750,650,750);

        graphicsContext.fillRect(850, 700, 100, 100);
        graphicsContext.strokeLine(900,700,900,800);
        graphicsContext.strokeLine(850,750,950,750);
        //Smoke pipe
        graphicsContext.setFill(Color.GREY);
        graphicsContext.fillRect(900, 350, 50, 150);
        //Roof
        double [] x = {450, 1050, 750};
        double [] y = {610, 610, 260};
        graphicsContext.setFill(Color.LIGHTGREEN);
        graphicsContext.fillPolygon(x, y, 3);
        //Smoke
        graphicsContext.setStroke(Color.BLACK);
        int yDim = 350;
        for (int i = 0; i < 8; i++) {
            graphicsContext.strokeLine(950, yDim, 900, yDim - 20);
            graphicsContext.strokeLine(900, yDim, 950, yDim - 20);
            yDim -= 20;
        }
    }

    public  void  sun(GraphicsContext graphicsContext){
        graphicsContext.setFill(Color.BLACK);
        graphicsContext.setLineWidth(3);
        int radius = 50;
        Dot centerDot  = new Dot(1500, 200);
        circleDots = new ArrayList<>();
        int stp = 25;
        double num = ((2 * Math.PI) / stp);
        double oldDotX = centerDot.x + 50;
        double oldDotY = centerDot.y;
        circleDots.add(new Dot(oldDotX, oldDotY));
        for (int i = 0; i <= stp; i++) {
            double newDotX = centerDot.x + radius * Math.cos(Math.PI / 7 + num * i);
            double newDotY = centerDot.y + radius * Math.sin(Math.PI / 7 + num * i);
            circleDots.add(new Dot(newDotX, newDotY));
        }
        graphicsContext.setFill(Color.YELLOW);
        graphicsContext.fillOval(centerDot.x - radius, centerDot.y - radius, radius * 2, radius * 2);
        graphicsContext.setStroke(Color.YELLOW);
        for (int i = 0; i < circleDots.size() - 1; i++) {
            graphicsContext.strokeLine(circleDots.get(i).x, circleDots.get(i).y, circleDots.get(i+1).x, circleDots.get(i+1).y);
        }

        for (int i = 1; i < circleDots.size(); i++) {
            graphicsContext.strokeLine(circleDots.get(i).x, circleDots.get(i).y, circleDots.get(i).x + radius * Math.cos(0 + num * i), circleDots.get(i).y + radius * Math.sin(0 + num * i));
        }
    }
}