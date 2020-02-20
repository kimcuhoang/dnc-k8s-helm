

{{- define "peopleapi.deployment.name" -}}
{{- $projectname := default .Chart.Name .Values.global.projectName -}}
{{- printf "%s-%s" $projectname "deployment" -}}
{{- end -}}

