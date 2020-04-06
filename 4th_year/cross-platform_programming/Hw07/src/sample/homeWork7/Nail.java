package sample.homeWork7;

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.text.Font;
import sample.Dot;
import sun.misc.Queue;

import java.util.ArrayList;
import java.util.PriorityQueue;

public class Nail {
    private GraphicsContext graphicsContext;
    private ArrayList <Integer> disks;
    private Queue <Integer> d;
    private Dot myLeftDot;
    private Dot myRightDot;

    public Nail (GraphicsContext graphicsContext, int numOfDisks, Dot myLeftDot, Dot myRightDot) {
        this.graphicsContext = graphicsContext;
        disks = new ArrayList();
        PriorityQueue<Integer> integerPriorityQueue = new PriorityQueue<>(7);
        this.myLeftDot = myLeftDot;
        this.myRightDot = myRightDot;
        for (int i = numOfDisks; i > 0 ; i--) {
            disks.add(i);
        }
    }

    public void draw () {
        graphicsContext.strokeLine(myLeftDot.x, myLeftDot.y, myRightDot.x, myRightDot.y);
        graphicsContext.strokeLine(myRightDot.x - 50, myRightDot.y, myRightDot.x - 50, myRightDot.y - 650);
        graphicsContext.setFont(Font.font("Times", 20));
        for (int i = 1; i <= disks.size(); i++) {
            graphicsContext.fillText(""+  disks.get(i - 1), myRightDot.x - 50, myRightDot.y - 25 * i);
        }
    }

    public void addDisk (int disk) {
        disks.add(disk);
    }

    public int getDisk () {
        int buff = disks.get(disks.size() - 1);
        disks.remove(disks.size() - 1);
        return buff;
    }

    public int getAll () {
        int buff = disks.get(0);
        disks.remove(0);
        return buff;
    }

    public boolean isEmpty () {
        return disks.isEmpty();
    }
}
