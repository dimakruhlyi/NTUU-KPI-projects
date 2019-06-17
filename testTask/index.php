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

?>