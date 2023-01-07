import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        try
        {
            //Üstteki kütüphaneleri import et
            //***************************Dosya yolunu burada aldık
            File obj = new File("C:\\Users\\tnrsn\\Desktop\\py\\test.nur");
            Scanner myReader = new Scanner(obj);
            while (myReader.hasNextLine())
            {
                //Dosyanın içindekileri yazdır
                String data = myReader.nextLine();
                System.out.println(data);
            }
        }
        catch (FileNotFoundException e)
        {
            //Hata varsa yazdır
            System.out.println("An error occurred.");
        }


    }
}