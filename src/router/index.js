import { createRouter, createWebHistory } from 'vue-router'
import Home from '../components/Home.vue'
import Contacts from '../components/Contacts.vue'
import Faq from '../components/Faq.vue'
import Page404 from '../components/Page404.vue'

const routes = [
  { path: '/', name: 'home', component: Home },
  { path: '/contacts', name: 'contacts', component: Contacts },
  { path: '/faq', name: 'faq', component: Faq },
  
  // Catch-all: ловит ВСЕ несуществующие маршруты → показывает Page404
  // ДОЛЖЕН БЫТЬ ПОСЛЕДНИМ в списке!
  { path: '/:pathMatch(.*)*', name: 'not-found', component: Page404 }
]

const router = createRouter({
  history: createWebHistory(),
  routes,
  scrollBehavior(to, from, savedPosition) {
    if (to.hash) {
      return { el: to.hash, behavior: 'smooth' }
    } else if (savedPosition) {
      return savedPosition
    } else {
      return { top: 0 }
    }
  }
})

export default router