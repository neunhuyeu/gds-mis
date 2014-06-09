@echo off
echo Running dump...
c:\wamp\bin\mysql\mysql5.6.12\bin\mysqldump -u root --result-file="c:\wamp\bin\mysql\backup_gds_mis.sql" gds_mis --add-drop-table
c:\wamp\bin\mysql\mysql5.6.12\bin\mysqldump -u root --result-file="c:\wamp\bin\mysql\backup_gds_mis_agenda.sql" gds_mis_agenda --add-drop-table
c:\wamp\bin\mysql\mysql5.6.12\bin\mysqldump -u root --result-file="c:\wamp\bin\mysql\backup_gds_mis_auth.sql" gds_mis_auth --add-drop-table


echo Done!