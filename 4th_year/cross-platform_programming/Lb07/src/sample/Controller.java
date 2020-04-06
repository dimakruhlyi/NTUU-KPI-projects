package sample;

import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.stage.Stage;

import java.io.IOException;

public class Controller {
    @FXML
    private void laba4 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("laba4/laba4.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    @FXML
    private void laba5 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("laba5/laba5.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    @FXML
    private void homeWork5 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("homeWork5/homeWork5.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    @FXML
    private void homeWork6 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("homeWork6/homeWork6.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    @FXML
    private void laba6 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("laba6/laba6.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    @FXML
    private void homeWork7 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("homeWork7/homeWork7.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    @FXML
    private void laba7 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("laba7/laba7.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    @FXML
    private void homeWork8 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("homeWork8/homeWork8.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    @FXML
    private void laba8 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("laba8/laba8.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    @FXML
    private void laba9 () throws IOException {
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getResource("laba9/laba9.fxml"));
        Scene scene = new Scene(root, 1366, 768);
        stage.setScene(scene);
        stage.show();
    }

    public static void gridBuild(GraphicsContext graphicsContext) {
        graphicsContext.setLineWidth(1);
        for (int x = 0; x < 1300; x += 20) {
            graphicsContext.setStroke(Color.LIGHTCORAL);
            graphicsContext.strokeLine(x, 0, x, 768);
            graphicsContext.setStroke(Color.GRAY);
            graphicsContext.setFont(Font.font("Times", 10));
            graphicsContext.strokeText(("" + (x)), (x + 2), 10);
        }

        for (int y = 0; y < 750; y += 20) {
            graphicsContext.setStroke(Color.LIGHTCORAL);
            graphicsContext.strokeLine(0, y, 1305, y);
            graphicsContext.setStroke(Color.GRAY);
            graphicsContext.setFont(Font.font("Times", 10));
            graphicsContext.strokeText(("" + (y)), 10, (y - 2));
        }
    }
}
