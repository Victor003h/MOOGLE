#!/bin/bash

echo " Press 1 to run the project"
echo " Press 2 for the report option "
echo " Press 3 for slides option" 
echo " Press 4 for show_report option"
echo " Press 5 for show_slides option"
echo " Press 6 for clean option"

run (){
	cd ..
	cd MoogleServer
	dotnet watch run Program.cs

}


report () {
	cd ..
	cd informe
	pdflatex -interaction=nonstopmode "document"

}


slides () {
	cd ..
	cd Presentacion
	pdflatex -interaction=nonstopmode "Presentacion"

}


show_report () {
	comando=""
	read -p " Type the display tool command that you want to use: " comando
	if [ ! -d "document.pdf" ]
	then
		report
	
	fi
	if [ -z "$comando" ]
	then 	
		 
		echo " The default command will be used."
		start "document.pdf"
		
	else	

		"$comando" "document.pdf"

	fi

}



show_slides () {
        comando=""
        read -p "Type the display tool command that you want to use:: " comando
        if [ ! -d "Presentacion.pdf" ]
        then
                slides
              
        fi
        if [ -z "$comando" ]
        then

                echo " The default command will be used."
                start "Presentacion.pdf"

        else

                "$comando" "Presentacion.pdf"

        fi

}


clean () {
	cd ..
	cd informe
	rm  -f *.log *.aux *.syntecx 
	cd ..
	cd Presentacion
	rm -f *.aux *.log *.nav *.out *.snm *.toc  
	echo " Temporary files have been deleted "
}



option=""
read -p " Press a option: " option

case $option in
	"1") run;;
	"2") report;;
	"3") slides;;
	"4") show_report;;
	"5") show_slides;;
	"6") clean;;	
	*) echo  "Invalid command";;
esac


