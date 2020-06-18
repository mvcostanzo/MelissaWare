<template>
    <div id="app">
        <MenuBar />
        <Teachers />
        <Home msg="Hello world!" />
    </div>
</template>

<script>
    import Home from './components/Home.vue';
    import MenuBar from './components/MenuBar.vue';
    import Teachers from './views/Teachers.vue';

    export default {
        name: 'app',
        components: {
            Home, MenuBar, Teachers
        }
    };
</script>

<style>
</style>

