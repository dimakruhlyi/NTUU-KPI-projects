package sample.homeWork6;

import javafx.scene.paint.Color;
import sample.Dot;

public class Cell {
    public Dot startDot;
    public int width; //ширина
    public int heigth;

    public Cell (Dot startDot, int heigth) {
        this.startDot = startDot;
        this.heigth = heigth;
        width = heigth;
    }
}
