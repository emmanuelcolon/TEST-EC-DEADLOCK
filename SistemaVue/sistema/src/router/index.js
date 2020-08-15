import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Persona from '../views/Persona.vue'
import Posicion_Trabajo from '../views/Posicion_Trabajo.vue'


Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/persona',
    name: 'persona',
    component: Persona
  },
  {
    path: '/Posicion_Trabajo',
    name: 'posicion-trabajo',
    component: Posicion_Trabajo
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
