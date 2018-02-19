         clear
         search_group = SPACE(10)
         boolean = .F.
         @ 35,35 say "Enter group for search: " get search_group
         read
     
         use First_table
         
     	 counter = 20
            FOR i = 1 TO RECCOUNT()  STEP 1       
               IF group = search_group
                 	boolean = .T.
                 	@ counter,10 say  surname
                 	@ counter,30 say  group
                 	@ counter,40 say  language
                 	@ counter,60 say  date
                 	@ counter,80 say  average
                 	counter = counter + 1
               	ENDIF 
                skip
            ENDFOR 
             
             IF boolean = .F.
             	@ 40,10 say "Thise group doesn't exist"
             ENDIF      
      use