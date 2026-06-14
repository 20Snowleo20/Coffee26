import { createRouter, createWebHistory } from 'vue-router'
import Home from '../components/Home.vue'
import Contacts from '../components/Contacts.vue'
import Faq from '../components/Faq.vue'
import Page404 from '../components/Page404.vue'
import Login from '../Login.vue'
import Register from '../Register.vue'
import Profile from '../Profile.vue'

const routes = [
  { path: '/', name: 'home', component: Home },
  { path: '/contacts', name: 'contacts', component: Contacts },
  { path: '/faq', name: 'faq', component: Faq },
  { path: '/page404', name: 'Page404', component: Page404 },
  { path: '/login', name: 'login', component: Login },
  { path: '/register', name: 'register', component: Register },
  { path: '/profile', name: 'profile', component: Profile },
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
router.beforeEach((to) => {

    if (
        to.path === '/profile' &&
        !localStorage.getItem('user')
    ) {
        return '/login'
    }

    return true
})
export default router
