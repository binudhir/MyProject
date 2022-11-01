public class timeFormat {
    static String result(String s){
        if(s.charAt(8)=='A'){
            if(Integer.valueOf(s.substring(0,2))==12)
            return "00" + s.substring(2, 8);
        }
        else if(s.charAt(8)=='P'){
            if(Integer.valueOf(s.substring(0,2))!=12){
                int hours=Integer.valueOf(s.substring(0, 2))+12;
                return "" + hours +s.substring(2, 8);
            }
        }

        return s.substring(0, 8);
    }

    public static void main(String[] args) {
        String s="03:05:05PM";
        System.out.println("The 24 Hour format is " + (result(s)));

    }
}
