<?php
    //                                    TASK 1 (Delete duplicated elements in array)
    $array = [1,1,1,2,2,2,2,3];
    $count = 0;
    $result = [];
    
    for($i = 0; $i<count($array); ++$i){
        for($j = 0;$j<$count; ++$j){
            if($array[$i] == $result[$j]){
                break;
            }
        }
        if($j == $count){
            $result[$count] = $array[$i];
            ++$count;
        }
    }
    
    foreach($result as $values){
        echo "$values,";
    }

 //                                    TASK 2 (Check meetings time function) 
$meetings = "1630 2030";
function check_meetings($str){
    $value_1 = (int)substr($str,0,2);
    $value_2 = (int)substr($str,5,2);
    $value_1_1 = (int)substr($str,2,2);
    $value_2_2 = (int)substr($str,7,2);
    
    
    if($value_1>$value_2){
        echo " ERROR!! <br/> $value_1 hours more than $value_2 hours!";
    }
    else{
        if(($value_1 == $value_2) and ($value_1_1>$value_2_2)){
            echo " ERROR!! <br/> $value_1 hours $value_1_1 minutes less than $value_2 hours $value_2_2 minutes!";
        }
        else{
            echo " Time of metting is correct!";
        }
    }
}

check_meetings($meetings);

?>
