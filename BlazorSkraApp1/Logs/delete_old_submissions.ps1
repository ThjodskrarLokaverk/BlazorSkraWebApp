# Import the module
Import-Module Az.Sql -Force
 
# Setup your parameters
$Params = @{
   'ServerInstance' = 'thjodskradbserver.database.windows.net';
   'Database' = 'BlazorSkraApp1_db';
   'Username' = '';
   'Password' = '';
   
   ##CREDITS for query: https://stackoverflow.com/questions/783726/how-do-i-delete-from-multiple-tables-using-inner-join-in-sql-server ##
   'Query' = '
        BEGIN TRAN         
        -- create temporary table for deleted IDs
        CREATE TABLE #DeleteId (
            Id INT NOT NULL PRIMARY KEY
        )
        -- save IDs of master table records (you want to delete) to temporary table  
        INSERT INTO #DeleteId(Id)
        SELECT DISTINCT SI.SubmissionId
        FROM SubmissionsInfo SI
        INNER JOIN Submissions S
            ON S.SubmissionId = SI.SubmissionId
            WHERE SI.SubmissionDate < GetDate() - 7; -- Only keep the latest submissions in the db.
        
        -- delete from first detail table using join syntax
        DELETE s
        FROM Submissions S
        INNER JOIN #DeleteId X
        ON S.SubmissionId = X.Id

        -- and finally delete from master table
        DELETE si
        FROM SubmissionsInfo SI

        INNER JOIN #DeleteId X
        ON SI.SubmissionId= X.Id        

        -- do not forget to drop the temp table
        DROP TABLE #DeleteId
        
        COMMIT
   '
}
Invoke-Sqlcmd @Params 
#Write to a log file, a confirmation that the script ran at a given time, have the latest entry at the top of the file for easier reading
$content = Get-Content -Path c:\hr\scripts\log.txt  #get content of file
$Output =@()  #new array
$Output += '_________________________________'
$Output += 'Delete function last ran at:     '
$Output +=  Get-Date
$Output +=$content
$Output | Out-file "c:\hr\scripts\log.txt"

 


