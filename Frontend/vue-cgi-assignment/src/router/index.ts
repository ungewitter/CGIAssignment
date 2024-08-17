import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/businessCards',
      name: 'businessCards',
      component: () => import('../views/BusinessCardsView.vue')
    },
    {
      path: '/add',
      name: 'add',
      component: () => import('../views/AddView.vue')
    },
    {
      path: '/update',
      name: 'update',
      component: () => import('../views/UpdateView.vue')
    },
    {
      path: '/delete',
      name: 'delete',
      component: () => import('../views/DeleteView.vue')
    },
  ]
})

export default router
