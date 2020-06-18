<template>
    <div>
        Teacher View {{teachers}}
    </div>
</template>

<script>
    export default {
        
        name: "Teachers",
        data: function() {
            return {teachers: []}
        },
        mounted: function () {
            fetch('https://localhost:44356/api/Teachers', {
                method: "GET"
            })
                .then(response => response.json())
                .then(data => { this.teachers = JSON.parse(JSON.stringify(data)); })
                .catch((error) => { console.log('Error', error); })
        }
    }
</script>

<style scoped>
</style>