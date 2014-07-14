SortXml 1.0.0.0
Copyright c  2014

  -i, --inputfile     Required. Input XML file to be processed. File to contain
                      syntactically valid XML data only.

  -o, --outputfile    Required. Output file with sorted XML data.

  -d, --depth         Positive integer value to indicate the depth of the XML
                      tree to be sorted. Default is to sort the entire tree.


  -l, --log           Log level. Error = 0, Warning = 1, Info = 2, Log = 3.
                      Default is to log error and warnings.

  --help              Display this help screen.

------------------------------------------------------------------------------------------------------------
Sample Input File (input.xml): 
<n0_0 a1="e" a0="c">
  <n0_2 a1="e" a0="f" />
  <n0_1 a1="e" a0="f" />
</n0_0>


Sample Output (output.xml):
<n0_0 a0="c" a1="e">
  <n0_1 a0="f" a1="e" />
  <n0_2 a0="f" a1="e" />
</n0_0>

Sample Execution: (log all and sort only nodes upto 1st level)

SortXml -i input.xml -o output.xml -d 1 -l 4
